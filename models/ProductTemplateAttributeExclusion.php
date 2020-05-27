<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "product_template_attribute_exclusion".
 *
 * @property int $id TRIAL
 * @property int|null $product_template_attribute_value_id TRIAL
 * @property int $product_tmpl_id TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial395 TRIAL
 *
 * @property ProductTemplateAttributeValue $productTemplateAttributeValue
 * @property ResUsers $createU
 * @property ResUsers $writeU
 */
class ProductTemplateAttributeExclusion extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'product_template_attribute_exclusion';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['product_template_attribute_value_id', 'product_tmpl_id', 'create_uid', 'write_uid'], 'integer'],
            [['product_tmpl_id'], 'required'],
            [['create_date', 'write_date'], 'safe'],
            [['trial395'], 'string', 'max' => 1],
            [['product_template_attribute_value_id'], 'exist', 'skipOnError' => true, 'targetClass' => ProductTemplateAttributeValue::className(), 'targetAttribute' => ['product_template_attribute_value_id' => 'id']],
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
            'product_template_attribute_value_id' => 'Product Template Attribute Value ID',
            'product_tmpl_id' => 'Product Tmpl ID',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial395' => 'Trial395',
        ];
    }

    /**
     * Gets query for [[ProductTemplateAttributeValue]].
     *
     * @return \yii\db\ActiveQuery|ProductTemplateAttributeValueQuery
     */
    public function getProductTemplateAttributeValue()
    {
        return $this->hasOne(ProductTemplateAttributeValue::className(), ['id' => 'product_template_attribute_value_id']);
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
     * @return ProductTemplateAttributeExclusionQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new ProductTemplateAttributeExclusionQuery(get_called_class());
    }
}
