<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "res_partner_category".
 *
 * @property int $id TRIAL
 * @property string|null $parent_path TRIAL
 * @property string $name TRIAL
 * @property int|null $color TRIAL
 * @property int|null $parent_id TRIAL
 * @property int|null $active TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial509 TRIAL
 *
 * @property ResUsers $createU
 * @property ResPartnerCategory $parent
 * @property ResPartnerCategory[] $resPartnerCategories
 * @property ResUsers $writeU
 */
class ResPartnerCategory extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'res_partner_category';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['parent_path', 'name'], 'string'],
            [['name'], 'required'],
            [['color', 'parent_id', 'active', 'create_uid', 'write_uid'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial509'], 'string', 'max' => 1],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['parent_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartnerCategory::className(), 'targetAttribute' => ['parent_id' => 'id']],
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
            'parent_path' => 'Parent Path',
            'name' => 'Name',
            'color' => 'Color',
            'parent_id' => 'Parent ID',
            'active' => 'Active',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial509' => 'Trial509',
        ];
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
     * Gets query for [[Parent]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerCategoryQuery
     */
    public function getParent()
    {
        return $this->hasOne(ResPartnerCategory::className(), ['id' => 'parent_id']);
    }

    /**
     * Gets query for [[ResPartnerCategories]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerCategoryQuery
     */
    public function getResPartnerCategories()
    {
        return $this->hasMany(ResPartnerCategory::className(), ['parent_id' => 'id']);
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
     * @return ResPartnerCategoryQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new ResPartnerCategoryQuery(get_called_class());
    }
}
