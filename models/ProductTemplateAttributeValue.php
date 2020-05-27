<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "product_template_attribute_value".
 *
 * @property int $id TRIAL
 * @property int|null $ptav_active TRIAL
 * @property int $product_attribute_value_id TRIAL
 * @property int $attribute_line_id TRIAL
 * @property float|null $price_extra TRIAL
 * @property int|null $product_tmpl_id TRIAL
 * @property int|null $attribute_id TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial405 TRIAL
 *
 * @property ProductTemplateAttributeExclusion[] $productTemplateAttributeExclusions
 * @property ResUsers $createU
 * @property ResUsers $writeU
 */
class ProductTemplateAttributeValue extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'product_template_attribute_value';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['ptav_active', 'product_attribute_value_id', 'attribute_line_id', 'product_tmpl_id', 'attribute_id', 'create_uid', 'write_uid'], 'integer'],
            [['product_attribute_value_id', 'attribute_line_id'], 'required'],
            [['price_extra'], 'number'],
            [['create_date', 'write_date'], 'safe'],
            [['trial405'], 'string', 'max' => 1],
            [['product_attribute_value_id', 'attribute_line_id'], 'unique', 'targetAttribute' => ['product_attribute_value_id', 'attribute_line_id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'ptav_active' => 'Ptav Active',
            'product_attribute_value_id' => 'Product Attribute Value ID',
            'attribute_line_id' => 'Attribute Line ID',
            'price_extra' => 'Price Extra',
            'product_tmpl_id' => 'Product Tmpl ID',
            'attribute_id' => 'Attribute ID',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial405' => 'Trial405',
        ];
    }

    /**
     * Gets query for [[ProductTemplateAttributeExclusions]].
     *
     * @return \yii\db\ActiveQuery|ProductTemplateAttributeExclusionQuery
     */
    public function getProductTemplateAttributeExclusions()
    {
        return $this->hasMany(ProductTemplateAttributeExclusion::className(), ['product_template_attribute_value_id' => 'id']);
    }

    /**
     * Gets query for [[CreateU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    /**
     * Gets query for [[WriteU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    /**
     * {@inheritdoc}
     * @return ProductTemplateAttributeValueQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new ProductTemplateAttributeValueQuery(get_called_class());
    }
}
